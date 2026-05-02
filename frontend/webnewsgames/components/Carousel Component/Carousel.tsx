"use client";

import Link from "next/link";
import React, { useEffect, useState } from "react";
import { ChevronLeft, ChevronRight } from "lucide-react";

interface Campeonato {
  id: number;
  nome: string;
  descricao: string;
  imagem: string;
  disponivel: boolean;
}

const campeonatos: Campeonato[] = [
  {
    id: 1,
    nome: "Campeonato Brasileiro Serie A",
    descricao: "A maior competicao nacional entre clubes do Brasil.",
    imagem: "/images/serie-a.jpg",
    disponivel: true,
  },
  {
    id: 2,
    nome: "Copa do Brasil 2025",
    descricao: "Torneio mata-mata com os melhores times do pais.",
    imagem: "/images/copa-brasil.jpg",
    disponivel: true,
  },
  {
    id: 3,
    nome: "Libertadores da America",
    descricao: "O sonho de todo clube sul-americano.",
    imagem: "/images/libertadores.jpg",
    disponivel: false,
  },
  {
    id: 4,
    nome: "Campeonato Paulista",
    descricao: "O torneio estadual mais tradicional do Brasil.",
    imagem: "/images/paulistao.jpg",
    disponivel: false,
  },
  {
    id: 5,
    nome: "Mundial de Clubes",
    descricao: "A disputa pelo titulo de melhor do mundo.",
    imagem: "/images/mundial.jpg",
    disponivel: true,
  },
];

export default function CarrosselCampeonatos() {
  const [currentIndex, setCurrentIndex] = useState(0);

  const prevSlide = () => {
    setCurrentIndex((prev) => (prev === 0 ? campeonatos.length - 1 : prev - 1));
  };

  const nextSlide = () => {
    setCurrentIndex((prev) => (prev === campeonatos.length - 1 ? 0 : prev + 1));
  };

  const goToSlide = (index: number) => {
    setCurrentIndex(index);
  };

  useEffect(() => {
    const intervalId = window.setInterval(() => {
      setCurrentIndex((prev) =>
        prev === campeonatos.length - 1 ? 0 : prev + 1,
      );
    }, 5000);

    return () => window.clearInterval(intervalId);
  }, []);

  return (
    <section>
      <div className="container w-[90%] mx-auto py-8 md:py-12">
        <div>
          <h1 className="text-3xl md:text-4xl font-bold text-center text-gray-800 mb-6">
            Campeonatos em Destaque
          </h1>
          <div className="relative bg-white rounded-2xl shadow-2xl overflow-hidden">
            <div
              className="flex transition-transform duration-500 ease-in-out"
              style={{ transform: `translateX(-${currentIndex * 100}%)` }}
            >
              {campeonatos.map((campeonato) => (
                <div
                  key={campeonato.id}
                  className="w-full bg-grey flex-shrink-0 flex flex-col lg:flex-row items-center justify-between gap-6 p-5 sm:p-6 md:p-10 lg:p-12"
                >
                  <div className="w-full lg:w-1/2">
                    <div className="bg-gray-200 border-2 border-dashed rounded-xl w-full h-56 sm:h-64 md:h-80 flex items-center justify-center text-gray-500 px-4 text-center">
                      <span className="text-base md:text-lg font-medium">
                        {campeonato.nome}
                      </span>
                    </div>
                  </div>

                  <div className="w-full lg:w-1/2 text-center lg:text-left pb-10 sm:pb-8 lg:pb-0">
                    <h2 className="text-2xl md:text-3xl font-bold text-gray-800 mb-4">
                      {campeonato.nome}
                    </h2>
                    <p className="text-gray-600 mb-8 leading-relaxed">
                      {campeonato.descricao}
                    </p>

                    <div className="flex flex-col sm:flex-row justify-center lg:justify-start gap-3">
                      {campeonato.disponivel ? (
                        <button
                          onClick={() =>
                            alert(`Inscricao no ${campeonato.nome}`)
                          }
                          className="bg-blue-700 hover:bg-blue-800 text-white font-bold py-3 px-8 rounded-lg shadow-lg hover:shadow-xl transition-all duration-300 transform hover:-translate-y-1"
                          style={{ backgroundColor: "#1e40af" }}
                        >
                          Inscrever-se
                        </button>
                      ) : (
                        <button
                          disabled
                          className="bg-red-600 text-white font-bold py-3 px-8 rounded-lg cursor-not-allowed opacity-90"
                        >
                          Encerrado
                        </button>
                      )}
                      <Link
                        href="/championships"
                        className="inline-flex items-center justify-center border border-blue-700 text-blue-700 bg-white font-bold py-3 px-8 rounded-lg shadow-lg hover:bg-blue-50 hover:shadow-xl transition-all duration-300 transform hover:-translate-y-1"
                      >
                        Acompanhar
                      </Link>
                    </div>
                  </div>
                </div>
              ))}
            </div>

            <button
              onClick={prevSlide}
              aria-label="Voltar campeonato"
              className="absolute left-2 sm:left-4 top-1/2 -translate-y-1/2 bg-white/80 hover:bg-white p-2 sm:p-3 rounded-full shadow-lg transition-all"
            >
              <ChevronLeft className="w-6 h-6 text-blue-700" />
            </button>
            <button
              onClick={nextSlide}
              aria-label="Avancar campeonato"
              className="absolute right-2 sm:right-4 top-1/2 -translate-y-1/2 bg-white/80 hover:bg-white p-2 sm:p-3 rounded-full shadow-lg transition-all"
            >
              <ChevronRight className="w-6 h-6 text-blue-700" />
            </button>

            <div className="absolute bottom-4 sm:bottom-6 left-1/2 -translate-x-1/2 flex space-x-2">
              {campeonatos.map((_, index) => (
                <button
                  key={index}
                  onClick={() => goToSlide(index)}
                  aria-label={`Ir para campeonato ${index + 1}`}
                  className={`w-3 h-3 rounded-full transition-all duration-300 ${
                    index === currentIndex
                      ? "bg-blue-700 w-8"
                      : "bg-gray-400 hover:bg-gray-600"
                  }`}
                />
              ))}
            </div>
          </div>
        </div>
      </div>
    </section>
  );
}
