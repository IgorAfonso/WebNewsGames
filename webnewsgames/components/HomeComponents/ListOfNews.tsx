import { LastNews } from "@/types/lastnews";
import NewsImage from "../../assets/GOdOfWar.jpeg";
import Image from "next/image";
import ListOfNewsBox from "./ListOfNewsBox";

export default function ListOfNews() {
  const LastNewsObject: LastNews[] = [
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

  return (
    <section className="md:container md:mx-auto px-4 py-8 m-10">
      <h2 className="text-2xl font-bold mb-4">Últimas Notícias</h2>
      <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
        {LastNewsObject.map((news) => (
          <div
            key={news.id}
            className="bg-grey rounded-lg shadow-lg p-4 w-full"
          >
            <ListOfNewsBox
              key={news.id}
              id={news.id}
              title={news.title}
              description={news.description}
            />
          </div>
        ))}
      </div>
    </section>
  );
}
