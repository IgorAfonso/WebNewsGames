"use client";

import Link from "next/link";
import Image from "next/image";
import { useEffect, useState } from "react";
import BreakingImage from "../../assets/GOdOfWar.jpeg";
import type { NewsSummary } from "@/models/NewsModels";
import { getNewsImageSource, getNewsList } from "@/services/NewsService";

export default function FeaturedNews() {
  const [featuredNews, setFeaturedNews] = useState<NewsSummary | null>(null);

  useEffect(() => {
    getNewsList(1).then((newsList) => setFeaturedNews(newsList[0] ?? null));
  }, []);

  const imageSource = getNewsImageSource(featuredNews?.imageBase64);
  const href = featuredNews ? `/news/${featuredNews.id}?from=/home` : "/home";

  return (
    <section className="container w-[90%] mx-auto py-8">
      <h2 className="text-2xl font-bold mb-4">Destaques</h2>
      <div className="bg-grey rounded-lg shadow-2xl p-6 flex flex-col md:flex-row content-center">
        <div className="w-full md:w-60 shrink-0">
          <Link href={href} aria-label="Abrir noticia em destaque">
            {imageSource ? (
              <img
                src={imageSource}
                alt={featuredNews?.title || "Noticia em destaque"}
                className="aspect-video w-full rounded object-cover"
              />
            ) : (
              <Image
                src={BreakingImage}
                alt="Noticia em destaque"
                className="aspect-video w-full rounded object-cover"
                width={300}
                height={100}
              />
            )}
          </Link>
        </div>
        <div className="w-full md:w-2/3 md:pl-6 mt-4 md:mt-0 justify-center">
          <h3 className="text-xl font-semibold text-app">
            {featuredNews?.title || "Noticia em destaque"}
          </h3>
          <p className="text-muted mt-2">
            {featuredNews?.description || "Carregando noticia em destaque..."}
          </p>
          <Link
            href={href}
            className="mt-4 bg-accent text-white px-4 py-2 rounded hover:bg-hoverDarkBlue read-more"
          >
            Leia Mais
          </Link>
        </div>
      </div>
    </section>
  );
}
