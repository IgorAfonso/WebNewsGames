"use client";

import { useEffect, useState } from "react";
import ListOfNewsBox from "./ListOfNewsBox";
import { getNewsList } from "@/services/NewsService";
import type { NewsSummary } from "@/models/NewsModels";

export default function ListOfNews() {
  const [newsList, setNewsList] = useState<NewsSummary[]>([]);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    getNewsList(3)
      .then(setNewsList)
      .finally(() => setIsLoading(false));
  }, []);

  return (
    <section className="container w-[90%] mx-auto py-8">
      <h2 className="text-2xl font-bold mb-4">Ultimas Noticias</h2>
      {isLoading && <p className="text-muted">Carregando noticias...</p>}
      <div className="grid grid-cols-1 md:grid-cols-2 xl:grid-cols-3 gap-6">
        {newsList.map((news) => (
          <div key={news.id} className="bg-grey rounded-lg shadow-2xl p-4 w-full">
            <ListOfNewsBox
              id={news.id}
              title={news.title}
              description={news.description}
              imageBase64={news.imageBase64}
            />
          </div>
        ))}
      </div>
    </section>
  );
}
