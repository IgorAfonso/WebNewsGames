"use client";

import Link from "next/link";
import { useParams, useSearchParams } from "next/navigation";
import { ArrowLeft } from "lucide-react";
import { useEffect, useMemo, useState } from "react";
import GeneralHeader from "@/components/DefaultHeaderComponent/GeneralHeader";
import Footer from "@/components/DefaultFooterComponent/Footer";
import type { News } from "@/models/NewsModels";
import { getNewsById, getNewsImageSource } from "@/services/NewsService";

type NewsBlock = {
  content: string | null;
  imageBase64: string | null;
  caption: string | null;
};

function buildBlocks(news: News): NewsBlock[] {
  return [
    {
      content: news.content,
      imageBase64: news.imageBase64,
      caption: news.imageCaption,
    },
    {
      content: news.content2,
      imageBase64: news.image2Base64,
      caption: news.image2Caption,
    },
    {
      content: news.content3,
      imageBase64: news.image3Base64,
      caption: news.image3Caption,
    },
  ].filter((block, index) => {
    if (index === 0) {
      return true;
    }

    return Boolean(block.content || block.imageBase64 || block.caption);
  });
}

export default function NewsDetailsPage() {
  const params = useParams<{ id: string }>();
  const searchParams = useSearchParams();
  const [news, setNews] = useState<News | null>(null);
  const [isLoading, setIsLoading] = useState(true);
  const [errorMessage, setErrorMessage] = useState<string | null>(null);
  const backHref = searchParams.get("from") || "/home";

  useEffect(() => {
    if (!params.id) {
      return;
    }

    setIsLoading(true);
    setErrorMessage(null);

    getNewsById(params.id)
      .then(setNews)
      .catch(() => setErrorMessage("Nao foi possivel carregar a noticia."))
      .finally(() => setIsLoading(false));
  }, [params.id]);

  const blocks = useMemo(() => (news ? buildBlocks(news) : []), [news]);

  return (
    <div className="flex min-h-screen flex-col bg-app text-app">
      <GeneralHeader PageDescriptor="Web News" />
      <main className="container mx-auto w-[90%] max-w-4xl flex-1 py-8">
        <Link
          href={backHref}
          className="mb-8 inline-flex items-center gap-2 rounded-md border border-app bg-surface px-4 py-2 text-sm font-semibold text-app transition-colors hover:text-accent"
        >
          <ArrowLeft size={18} aria-hidden="true" />
          Voltar
        </Link>

        {isLoading && (
          <section className="rounded-lg bg-surface p-6 shadow-xl">
            <p className="text-muted">Carregando noticia...</p>
          </section>
        )}

        {errorMessage && (
          <section className="rounded-lg border border-app bg-surface p-6 shadow-xl">
            <h1 className="text-2xl font-bold">Noticia indisponivel</h1>
            <p className="mt-3 text-muted">{errorMessage}</p>
          </section>
        )}

        {news && !isLoading && !errorMessage && (
          <article className="space-y-8">
            <header className="border-b border-app pb-6">
              <h1 className="text-3xl font-bold leading-tight md:text-5xl">
                {news.title || "Noticia sem titulo"}
              </h1>
              {news.authorName && (
                <p className="mt-4 text-sm font-medium text-muted">
                  Por {news.authorName}
                </p>
              )}
            </header>

            {blocks.map((block, index) => {
              const imageSource = getNewsImageSource(block.imageBase64);

              return (
                <section key={index} className="space-y-5">
                  {block.content && (
                    <p className="text-lg leading-8 text-app">{block.content}</p>
                  )}

                  {imageSource && (
                    <figure className="space-y-3">
                      <img
                        src={imageSource}
                        alt={block.caption || news.title || "Imagem da noticia"}
                        className="max-h-[520px] w-full rounded-lg object-contain shadow-xl"
                      />
                      {block.caption && (
                        <figcaption className="text-sm text-muted">
                          {block.caption}
                        </figcaption>
                      )}
                    </figure>
                  )}
                </section>
              );
            })}
          </article>
        )}
      </main>
      <Footer />
    </div>
  );
}
