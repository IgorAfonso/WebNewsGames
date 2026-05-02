import Image from "next/image";
import BackGroundImage from "@/assets/CommunityFindImage.png";

export default function FindDiscutionsComponent() {
  return (
    <section className="bg-accent py-8 md:py-12 lg:py-16">
      <div className="container w-[90%] mx-auto">
        <div className="grid grid-cols-1 md:grid-cols-2 items-center gap-0">
          <div className="flex justify-center md:justify-end bg-accent">
            <div className="relative w-full max-w-md lg:max-w-lg bg-accent">
              <Image
                src={BackGroundImage}
                width={1000}
                height={1000}
                alt="Comunidade encontrando discussoes"
                className="w-full h-auto object-contain bg-accent"
                priority
              />
            </div>
          </div>

          <div className="flex w-full flex-col items-end justify-center gap-6 pt-6 md:pt-0">
            <h2 className="w-full text-right text-3xl md:text-4xl lg:text-5xl font-bold text-white leading-tight">
              Pesquisar Artigos
            </h2>

            <input
              type="text"
              placeholder="Digite aqui..."
              className="w-full px-5 py-3 bg-white text-gray-800 placeholder-gray-500 rounded-lg border border-gray-300 focus:outline-none focus:ring-2 focus:ring-blue-300 focus:border-transparent transition-all duration-200 shadow-md text-base"
            />
          </div>
        </div>
      </div>
    </section>
  );
}
