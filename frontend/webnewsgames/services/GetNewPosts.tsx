import { CardProps } from "@/types/CardProps";

const basePosts: CardProps[] = [
  {
    title: "Vale a pena comprar um PS5 em 2025 ou esperar o PS6?",
    description:
      "Estou com duvida se ainda compensa pegar o PS5 esse ano. Alguem mais acha que o PS6 vai ser anunciado logo?",
    user: "@NeoGamerBR",
  },
  {
    title: "Qual o jogo com melhor historia que voce ja jogou?",
    description:
      "Estou procurando algo com enredo forte, tipo The Last of Us ou Red Dead. Aceito recomendacoes!",
    user: "@NarrativaXP",
  },
  {
    title: "Problemas com FPS no PC apos atualizacao do Windows 11",
    description:
      "Meu desempenho caiu muito em jogos como Valorant e Warzone depois da ultima atualizacao. Alguem passando por isso?",
    user: "@FPSDrop",
  },
  {
    title: "Ajuda: Melhor monitor custo-beneficio para PS5",
    description:
      "Quero investir num monitor bom, mas que nao custe um rim. Precisa ter 120Hz e HDMI 2.1. Dicas?",
    user: "@ConsoleVision",
  },
  {
    title: "Mods que realmente melhoram Skyrim em 2025",
    description:
      "Voltei a jogar Skyrim e queria sugestoes atualizadas de mods que deixam o game mais bonito ou imersivo.",
    user: "@DovahModder",
  },
  {
    title: "Quem ainda joga MMORPG em 2025?",
    description:
      "Sinto falta da epoca de Tibia, Mu, Ragnarok. Ainda tem alguma comunidade ativa por ai? Bora jogar junto?",
    user: "@MMOsaudade",
  },
];

export default function GetNewPosts(): CardProps[] {
  return Array.from({ length: 36 }, (_, index) => {
    const basePost = basePosts[index % basePosts.length];
    const articleNumber = index + 1;

    return {
      ...basePost,
      title: `${basePost.title} #${articleNumber}`,
    };
  });
}
