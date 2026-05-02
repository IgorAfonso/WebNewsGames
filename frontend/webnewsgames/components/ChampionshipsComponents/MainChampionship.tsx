"use client";

import Image from "next/image";
import MainImage from "@/assets/GOdOfWar.jpeg";

export default function MainChampionship() {
  return (
    <section className="container w-[90%] mx-auto my-8 rounded-lg bg-white p-4 sm:p-5 shadow-2xl">
      <div className="grid grid-cols-1 md:grid-cols-[240px_1fr_auto] items-center gap-4">
        <Image
          src={MainImage}
          width={360}
          height={180}
          alt="Campeonato God of War 2025"
          className="h-40 w-full rounded-lg object-cover md:h-32"
        />

        <div className="text-center md:text-left">
          <h1 className="font-bold text-xl md:text-2xl text-gray-900">
            Campeonato God of War 2025
          </h1>
          <p className="mt-2 text-gray-600">
            Inscricoes abertas ate 20/07/2025. Inscreva-se agora!
          </p>
        </div>

        <button className="w-full md:w-auto bg-primary text-white px-5 py-3 rounded-lg font-semibold hover:bg-accent transition">
          Inscrever-se
        </button>
      </div>
    </section>
  );
}
