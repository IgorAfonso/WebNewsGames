"use client";

import { useMemo, useState } from "react";
import GetNewPosts from "@/services/GetNewPosts";
import DefaultCard from "../CardComponent/WhiteCard";
import { AlertCircle } from "lucide-react";

const ARTICLES_PER_PAGE = 12;

export default function NewPosts() {
  const [currentPage, setCurrentPage] = useState(1);
  const posts = useMemo(() => GetNewPosts(), []);
  const totalPages = Math.ceil(posts.length / ARTICLES_PER_PAGE);

  const currentArticles = useMemo(() => {
    const start = (currentPage - 1) * ARTICLES_PER_PAGE;
    return posts.slice(start, start + ARTICLES_PER_PAGE);
  }, [currentPage, posts]);

  if (!posts || posts.length === 0) {
    return (
      <section className="container w-[90%] mx-auto my-10 flex flex-col items-center justify-center py-16 text-center">
        <AlertCircle className="w-16 h-16 text-gray-400 mb-4" />
        <p className="text-lg text-gray-600 font-medium">
          Nenhum artigo novo no momento.
        </p>
        <p className="text-sm text-gray-500 mt-1">Volte em breve!</p>
      </section>
    );
  }

  return (
    <section className="container w-[90%] mx-auto my-10">
      <h2 className="text-2xl font-bold mb-5">Artigos Recentes</h2>

      <div className="grid grid-cols-1 sm:grid-cols-2 xl:grid-cols-3 gap-5 lg:gap-6">
        {currentArticles.map((post) => (
          <DefaultCard
            key={`${post.title}-${post.user}`}
            title={post.title}
            description={post.description}
            user={post.user}
          />
        ))}
      </div>

      <nav
        aria-label="Paginas de artigos"
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
