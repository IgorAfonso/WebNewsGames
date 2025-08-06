import { LastNews } from "@/types/lastnews";
import ListOfNewsBox from "./ListOfNewsBox";
import GetLastNews from "@/services/GetLastNews";

export default function ListOfNews() {
  const LastNewsObject: LastNews[] = GetLastNews();

  return (
    <section className="md:container md:mx-auto px-4 py-8 m-10">
      <h2 className="text-2xl font-bold mb-4">Últimas Notícias</h2>
      <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
        {LastNewsObject.map((news) => (
          <div
            key={news.id}
            className="bg-grey rounded-lg shadow-2xl border-1 p-4 w-full"
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
