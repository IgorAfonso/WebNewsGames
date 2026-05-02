import { LastNews } from "@/types/lastnews";

export default function GetGeneralNews(): LastNews[] {
  return Array.from({ length: 90 }, (_, index) => {
    const id = index + 1;

    return {
      id,
      title: `Noticia geral ${id}`,
      description:
        "Resumo rapido com os principais pontos da noticia para leitura geral.",
    };
  });
}
