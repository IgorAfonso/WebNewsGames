"use client";

import React from "react";

interface Campeonato {
  id: number;
  nome: string;
  disponivel: boolean;
}

export default function MostRecentyChampionships() {
  const campeonatos: Campeonato[] = [
    { id: 1, nome: "Campeonato Brasileiro Série A", disponivel: true },
    { id: 2, nome: "Copa do Brasil 2025", disponivel: true },
    { id: 3, nome: "Libertadores da América", disponivel: false },
    { id: 4, nome: "Campeonato Paulista", disponivel: false },
    { id: 5, nome: "Mundial de Clubes", disponivel: true },
  ];

  return (
    <section className="container w-[90%] mx-auto shadow-2xl my-5 border rounded-2xl">
      <div className="min-h-screen bg-gray-50 py-8 px-4">
        <div className="max-w-4xl mx-auto">
          <h1 className="text-3xl font-bold text-gray-800 mb-8 text-center">
            Campeonatos Disponíveis
          </h1>

          <div className="overflow-hidden rounded-lg shadow-lg">
            <table className="w-full bg-white">
              <thead>
                <tr className="bg-primary text-white">
                  <th className="px-6 py-4 text-left text-sm font-semibold uppercase tracking-wider">
                    Nome do Campeonato
                  </th>
                  <th className="px-6 py-4 text-center text-sm font-semibold uppercase tracking-wider">
                    Ação
                  </th>
                </tr>
              </thead>
              <tbody className="divide-y divide-gray-200">
                {campeonatos.map((campeonato) => (
                  <tr
                    key={campeonato.id}
                    className="hover:bg-gray-50 transition-colors"
                  >
                    <td className="px-6 py-4 whitespace-nowrap text-gray-800 font-medium">
                      {campeonato.nome}
                    </td>
                    <td className="px-6 py-4 text-center">
                      {campeonato.disponivel ? (
                        <button
                          className="bg-primary hover:bg-accent text-white font-semibold py-2 px-6 rounded-md transition-all duration-200 shadow-md hover:shadow-lg transform hover:-translate-y-0.5"
                          style={{ backgroundColor: "#1e40af" }}
                          onClick={() =>
                            alert(`Inscrição no ${campeonato.nome}`)
                          }
                        >
                          Inscrever-se
                        </button>
                      ) : (
                        <button
                          disabled
                          className="bg-red-600 text-white font-semibold py-2 px-6 rounded-md cursor-not-allowed opacity-90"
                        >
                          Encerrado
                        </button>
                      )}
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </section>
  );
}
