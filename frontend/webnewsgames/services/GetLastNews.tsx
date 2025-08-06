import { LastNews } from "@/types/lastnews";

export default function GetLastNews(): LastNews[] {
  const LastNews = [
    {
      id: 1,
      title: "Título da Notícia 1",
      description: "Resumo breve da notícia para atrair o leitor...",
    },
    {
      id: 2,
      title: "Título da Notícia 2",
      description: "Resumo breve da notícia para atrair o leitor...",
    },
    {
      id: 3,
      title: "Título da Notícia 3",
      description: "Resumo breve da notícia para atrair o leitor...",
    },
  ];

  return LastNews;
}
