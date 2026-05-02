"use client";

import { useMemo, useState } from "react";
import Image from "next/image";
import MainImage from "@/assets/GOdOfWar.jpeg";

interface Campeonato {
  id: number;
  nome: string;
  descricao: string;
  disponivel: boolean;
}

const campeonatosVigentes: Campeonato[] = [
  {
    id: 1,
    nome: "Campeonato Brasileiro Serie A",
    descricao: "Temporada ativa com inscricoes abertas.",
    disponivel: true,
  },
  {
    id: 2,
    nome: "Copa do Brasil 2025",
    descricao: "Chaves abertas para novos participantes.",
    disponivel: true,
  },
  {
    id: 3,
    nome: "Mundial de Clubes",
    descricao: "Disputa global em andamento.",
    disponivel: true,
  },
];

const campeonatosEncerrados: Campeonato[] = Array.from(
  { length: 45 },
  (_, index) => {
    const id = index + 1;

    return {
      id,
      nome: `Campeonato Encerrado ${id}`,
      descricao: "Competicao finalizada e disponivel para consulta.",
      disponivel: false,
    };
  },
);

const ENDED_PER_COLUMN = 10;
const ENDED_COLUMNS_PER_PAGE = 3;
const ENDED_PER_PAGE = ENDED_PER_COLUMN * ENDED_COLUMNS_PER_PAGE;

export default function MostRecentyChampionships() {
  const [currentPage, setCurrentPage] = useState(1);
  const totalPages = Math.ceil(campeonatosEncerrados.length / ENDED_PER_PAGE);

  const currentEndedColumns = useMemo(() => {
    const pageStart = (currentPage - 1) * ENDED_PER_PAGE;
    const pageItems = campeonatosEncerrados.slice(
      pageStart,
      pageStart + ENDED_PER_PAGE,
    );

    return Array.from({ length: ENDED_COLUMNS_PER_PAGE }, (_, columnIndex) => {
      const columnStart = columnIndex * ENDED_PER_COLUMN;
      return pageItems.slice(columnStart, columnStart + ENDED_PER_COLUMN);
    });
  }, [currentPage]);

  return (
    <div className="container w-[90%] mx-auto my-8 space-y-8">
      <section className="rounded-lg bg-white p-4 sm:p-6 shadow-2xl">
        <div className="mb-5 flex flex-col gap-2 sm:flex-row sm:items-end sm:justify-between">
          <div>
            <h1 className="text-2xl md:text-3xl font-bold text-gray-800">
              Campeonatos Vigentes
            </h1>
            <p className="text-sm text-gray-600">
              Competicoes ativas para acompanhar ou participar.
            </p>
          </div>
        </div>

        <div className="grid grid-cols-1 md:grid-cols-2 xl:grid-cols-3 gap-5">
          {campeonatosVigentes.map((campeonato) => (
            <article
              key={campeonato.id}
              className="rounded-lg bg-gray-50 p-4 text-center shadow-lg"
            >
              <Image
                src={MainImage}
                width={420}
                height={220}
                alt={campeonato.nome}
                className="h-52 w-full rounded-lg object-cover md:h-60"
              />
              <h2 className="mt-4 text-lg font-bold text-gray-900">
                {campeonato.nome}
              </h2>
              <p className="mx-auto mt-2 max-w-sm text-sm text-gray-600">
                {campeonato.descricao}
              </p>
              <div className="mt-4 flex flex-col gap-2 sm:flex-row">
                <button
                  type="button"
                  onClick={() => alert(`Inscricao no ${campeonato.nome}`)}
                  className="flex-1 rounded-md bg-primary px-4 py-2 text-sm font-semibold text-white shadow-md transition hover:bg-accent"
                >
                  Inscrever-se
                </button>
                <button
                  type="button"
                  onClick={() => alert(`Acompanhar ${campeonato.nome}`)}
                  className="flex-1 rounded-md border border-blue-700 bg-white px-4 py-2 text-sm font-semibold text-blue-700 shadow-md transition hover:bg-blue-50"
                >
                  Acompanhar
                </button>
              </div>
            </article>
          ))}
        </div>
      </section>

      <section className="rounded-lg bg-white p-4 sm:p-6 shadow-2xl">
        <h1 className="text-2xl md:text-3xl font-bold text-gray-800 mb-5">
          Campeonatos Encerrados
        </h1>

        <div className="grid grid-cols-1 lg:grid-cols-3 gap-6">
          {currentEndedColumns.map((column, columnIndex) => (
            <div
              key={columnIndex}
              className="rounded-lg bg-white p-4 shadow-xl"
            >
              <ul className="divide-y divide-gray-200">
                {column.map((campeonato) => (
                  <li key={campeonato.id} className="py-3 first:pt-0 last:pb-0">
                    <button
                      type="button"
                      onClick={() => alert(`Acompanhar ${campeonato.nome}`)}
                      className="block w-full text-left group"
                    >
                      <h2 className="text-base font-semibold text-gray-900 group-hover:text-blue-700 transition-colors">
                        {campeonato.nome}
                      </h2>
                      <p className="mt-1 text-sm text-gray-600 leading-relaxed">
                        {campeonato.descricao}
                      </p>
                    </button>
                  </li>
                ))}
              </ul>
            </div>
          ))}
        </div>

        <nav
          aria-label="Paginas de campeonatos encerrados"
          className="mt-6 flex flex-wrap justify-center gap-2"
        >
          {Array.from({ length: totalPages }, (_, index) => {
            const page = index + 1;
            const isCurrentPage = page === currentPage;

            return (
              <button
                key={page}
                type="button"
                onClick={() => setCurrentPage(page)}
                aria-current={isCurrentPage ? "page" : undefined}
                className={`min-w-10 rounded-md border px-3 py-2 text-sm font-semibold transition-colors ${
                  isCurrentPage
                    ? "border-blue-700 bg-blue-700 text-white"
                    : "border-gray-300 bg-white text-gray-700 hover:border-blue-700 hover:text-blue-700"
                }`}
              >
                {page}
              </button>
            );
          })}
        </nav>
      </section>
    </div>
  );
}
