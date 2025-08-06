"use client";
import { CardProps } from "@/types/CardProps";

export default function DefaultCard(props: CardProps) {
  return (
    <div className="flex flex-col p-5 gap-5 shadow-2xl justify-around w-full h-full bg-white border border-gray-500 rounded-lg">
      <div className="gap-1">
        <h1 className="font-bold">Título:</h1>
        <h1>{props.title}</h1>
      </div>
      <div className="gap-1">
        <h2 className="font-bold">Breve Resumo:</h2>
        <h2>{props.description}</h2>
      </div>
      <div className="gap-1">
        <h3 className="font-bold">Usuário:</h3>
        <h3>{props.user}</h3>
      </div>
      <button
        onClick={() => alert("CLickou no Leia Mais")}
        className="mt-4 text-accent hover:underline read-more"
      >
        Leia Mais
      </button>
    </div>
  );
}
