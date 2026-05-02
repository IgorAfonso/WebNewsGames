"use client";

import { useMemo, useState } from "react";
import GetGeneralNews from "@/services/GetGeneralNews";

const NEWS_PER_COLUMN = 10;
const COLUMNS_PER_PAGE = 3;
const NEWS_PER_PAGE = NEWS_PER_COLUMN * COLUMNS_PER_PAGE;

export default function GeneralNewsSection() {
  const [currentPage, setCurrentPage] = useState(1);
  const generalNews = useMemo(() => GetGeneralNews(), []);
  const totalPages = Math.ceil(generalNews.length / NEWS_PER_PAGE);

  const currentColumns = useMemo(() => {
    const pageStart = (currentPage - 1) * NEWS_PER_PAGE;
    const pageNews = generalNews.slice(pageStart, pageStart + NEWS_PER_PAGE);

    return Array.from({ length: COLUMNS_PER_PAGE }, (_, columnIndex) => {
      const columnStart = columnIndex * NEWS_PER_COLUMN;
      return pageNews.slice(columnStart, columnStart + NEWS_PER_COLUMN);
    });
  }, [currentPage, generalNews]);

  return (
    <section className="container w-[90%] mx-auto py-8">
      <h2 className="text-2xl font-bold mb-4">Noticias Gerais</h2>

      <div className="grid grid-cols-1 lg:grid-cols-3 gap-6">
        {currentColumns.map((column, columnIndex) => (
          <div
            key={columnIndex}
            className="bg-white rounded-lg shadow-2xl p-4"
          >
            <ul className="divide-y divide-gray-200">
              {column.map((news) => (
                <li key={news.id} className="py-3 first:pt-0 last:pb-0">
                  <button
                    type="button"
                    onClick={() => alert(`Clicou em ${news.title}`)}
                    className="block w-full text-left group"
                  >
                    <h3 className="text-base font-semibold text-gray-900 group-hover:text-blue-700 transition-colors">
                      {news.title}
                    </h3>
                    <p className="mt-1 text-sm text-gray-600 leading-relaxed">
                      {news.description}
                    </p>
                  </button>
                </li>
              ))}
            </ul>
          </div>
        ))}
      </div>

      <nav
        aria-label="Paginas de noticias gerais"
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
  );
}
