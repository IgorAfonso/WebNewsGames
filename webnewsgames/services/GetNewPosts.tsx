import { CardProps } from "@/types/CardProps";

export default function GetNewPosts(): CardProps[] {
  const NewPosts: CardProps[] = [
    {
      title: "Vale a pena comprar um PS5 em 2025 ou esperar o PS6?",
      description:
        "Estou com dúvida se ainda compensa pegar o PS5 esse ano. Alguém mais acha que o PS6 vai ser anunciado logo?",
      user: "@NeoGamerBR",
    },
    {
      title: "Qual o jogo com melhor história que você já jogou?",
      description:
        "Estou procurando algo com enredo forte, tipo The Last of Us ou Red Dead. Aceito recomendações!",
      user: "@NarrativaXP",
    },
    {
      title: "Problemas com FPS no PC após atualização do Windows 11",
      description:
        "Meu desempenho caiu muito em jogos como Valorant e Warzone depois da última atualização. Alguém passando por isso?",
      user: "@FPSDrop",
    },
    {
      title: "Ajuda: Melhor monitor custo-benefício para PS5",
      description:
        "Quero investir num monitor bom, mas que não custe um rim. Precisa ter 120Hz e HDMI 2.1. Dicas?",
      user: "@ConsoleVision",
    },
    {
      title: "Mods que realmente melhoram Skyrim em 2025",
      description:
        "Voltei a jogar Skyrim e queria sugestões atualizadas de mods que deixam o game mais bonito ou imersivo.",
      user: "@DovahModder",
    },
    {
      title: "Quem ainda joga MMORPG em 2025?",
      description:
        "Sinto falta da época de Tibia, Mu, Ragnarok. Ainda tem alguma comunidade ativa por aí? Bora jogar junto?",
      user: "@MMOsaudade",
    },
  ];

  return NewPosts;
}
