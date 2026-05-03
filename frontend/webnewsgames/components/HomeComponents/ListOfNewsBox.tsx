"use client";
import Link from "next/link";
import Image from "next/image";
import NewsImage from "../../assets/GOdOfWar.jpeg";
import type { NewsSummary } from "@/models/NewsModels";
import { getNewsImageSource } from "@/services/NewsService";

export default function ListOfNewsBox(props: NewsSummary) {
  const imageSource = getNewsImageSource(props.imageBase64);
  const href = `/news/${props.id}?from=/home`;

  return (
    <div>
      <Link href={href} aria-label={`Abrir noticia ${props.title}`}>
        {imageSource ? (
          <img
            src={imageSource}
            alt={props.title}
            className="mb-4 aspect-video w-full rounded object-cover shadow-2xl"
          />
        ) : (
          <Image
            src={NewsImage}
            width={300}
            height={100}
            alt={props.title}
            className="mb-4 aspect-video w-full rounded object-cover shadow-2xl"
          />
        )}
      </Link>
      <h3 className="text-lg font-semibold text-app">{props.title}</h3>
      <p className="line-clamp-3 text-muted">{props.description}</p>
      <Link href={href} className="mt-4 inline-block text-accent hover:underline read-more">
        Leia Mais
      </Link>
    </div>
  );
}
