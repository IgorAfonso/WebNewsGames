import Image from "next/image";
import BackGroundImage from "@/assets/CommunityFindImage.png";

export default function FindDiscutionsComponent() {
  return (
    <div className="flex flex-col md:flex-row bg-accent items-center md:justify-between container mx-auto">
      <div className="sm:items-center md:max-w-[50%]">
        <Image
          src={BackGroundImage}
          width={1000}
          height={1000}
          alt="BG Picture"
        />
      </div>
      <div className="md:max-w-[50%] p-2 md:p-5 flex flex-col items-start justify-around ">
        <h2 className="text-3xl text-white font-bold py-5">
          Pesquisar Artigos
        </h2>
        <input
          type="text"
          placeholder="Digite aqui..."
          className="w-full bg-white border border-gray-300 text-black placeholder-gray-500 px-4 py-2 rounded focus:outline-none focus:ring-2 focus:ring-blue-400"
        ></input>
      </div>
    </div>
  );
}
