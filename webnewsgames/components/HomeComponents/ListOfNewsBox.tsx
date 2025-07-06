"use client";
import Image from "next/image";
import NewsImage from "../../assets/GOdOfWar.jpeg";
import { LastNews } from "@/types/lastnews";

export default function ListOfNewsBox(props: LastNews) {
  return (
    <div>
      <Image
        src={NewsImage}
        width={300}
        height={100}
        alt={props.title}
        className="w-full rounded shadow-2xl mb-4"
      />
      <h3 className="text-lg font-semibold">{props.title}</h3>
      <p className="text-gray-600">{props.description}</p>
      <button
        onClick={() => alert("CLickou no Leia Mais")}
        className="mt-4 text-accent hover:underline read-more"
      >
        Leia Mais
      </button>
    </div>
  );
}
