"use client";
import Image from "next/image";
import BreakingImage from "../../assets/GOdOfWar.jpeg";

export default function FeaturedNews() {
  return (
    <section className="m-10 md:container md:mx-auto px-4 py-8">
      <h2 className="text-2xl font-bold mb-4">Destaques</h2>
      <div className="bg-grey rounded-lg shadow-2xl border-1 p-6 flex flex-col md:flex-row content-center">
        <div className="md:w-60">
          <Image
            src={BreakingImage}
            alt="Notícia em destaque"
            className="w-full rounded"
            width={300}
            height={100}
          />
        </div>
        <div className="md:w-2/3 md:pl-6 mt-4 md:mt-0 justify-center">
          <h3 className="text-xl font-semibold">
            Título da Notícia em Destaque
          </h3>
          <p className="text-gray-600 mt-2">
            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do
            eiusmod tempor incididunt ut labore et dolore magna aliqua.
          </p>
          <button
            onClick={() => alert("CLickou no Leiame")}
            className="mt-4 bg-accent text-white px-4 py-2 rounded hover:bg-hoverDarkBlue read-more"
          >
            Leia Mais
          </button>
        </div>
      </div>
    </section>
  );
}
