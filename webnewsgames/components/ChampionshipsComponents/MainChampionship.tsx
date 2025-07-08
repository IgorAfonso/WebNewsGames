"use client";
import Image from "next/image";
import MainImage from "@/assets/GOdOfWar.jpeg";

export default function MainChampionship() {
  return (
    <div className="container w-[90%] mx-auto shadow-2xl my-5 border rounded-2xl p-5 flex flex-col items-center justify-center">
      <h1 className="font-bold text-center text-2xl mb-2">
        Campeonato God of War 2025
      </h1>
      <Image
        src={MainImage}
        width={300}
        height={100}
        alt="Picture of the author"
      />
      <h2 className="text-center mb-4">
        Inscrições abertas até 20/07/2025. Inscreva-se agora!
      </h2>
      <button className="bg-primary text-white h-10 w-32 rounded-2xl hover:bg-secondary transition">
        Inscrever-se
      </button>
    </div>
  );
}
