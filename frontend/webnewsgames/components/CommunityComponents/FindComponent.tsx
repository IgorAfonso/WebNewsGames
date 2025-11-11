import Image from "next/image";
import BackGroundImage from "@/assets/CommunityFindImage.png";

export default function FindDiscutionsComponent() {
  return (
    <div className="bg-accent py-8 md:py-12 lg:py-16">
      <div className="container mx-auto px-4">
        <div className="flex flex-col md:flex-row items-center gap-8 lg:gap-12">
          {/* Imagem - 50% da largura no desktop */}
          <div className="w-full md:w-1/2 flex justify-center md:justify-end">
            <div className="relative w-full max-w-md lg:max-w-lg">
              <Image
                src={BackGroundImage}
                width={1000}
                height={1000}
                alt="Comunidade encontrando discussões"
                className="w-full h-auto rounded-xl shadow-2xl object-cover"
                priority
              />
            </div>
          </div>

          {/* Texto + Input - 50% da largura */}
          <div className="w-full md:w-1/2 flex flex-col items-start justify-center space-y-6">
            <h2 className="text-3xl md:text-4xl lg:text-5xl font-bold text-white leading-tight">
              Pesquisar Artigos
            </h2>

            <div className="w-full max-w-md">
              <input
                type="text"
                placeholder="Digite aqui..."
                className="w-full px-5 py-3 bg-white text-gray-800 placeholder-gray-500 
                         rounded-lg border border-gray-300 
                         focus:outline-none focus:ring-2 focus:ring-blue-500 
                         focus:border-transparent transition-all duration-200 
                         shadow-md text-base"
              />
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
