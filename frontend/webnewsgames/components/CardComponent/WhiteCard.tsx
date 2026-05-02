"use client";

import { CardProps } from "@/types/CardProps";

export default function DefaultCard(props: CardProps) {
  return (
    <div className="flex h-full w-full flex-col justify-between gap-5 rounded-lg bg-white p-5 shadow-xl">
      <div className="space-y-1">
        <h1 className="font-bold">Titulo:</h1>
        <p>{props.title}</p>
      </div>
      <div className="space-y-1">
        <h2 className="font-bold">Breve Resumo:</h2>
        <p>{props.description}</p>
      </div>
      <div className="space-y-1">
        <h3 className="font-bold">Usuario:</h3>
        <p>{props.user}</p>
      </div>
      <button
        onClick={() => alert("Clicou no Leia Mais")}
        className="mt-4 self-start text-accent hover:underline read-more"
      >
        Leia Mais
      </button>
    </div>
  );
}
