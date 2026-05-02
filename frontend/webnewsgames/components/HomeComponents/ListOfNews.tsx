import { LastNews } from "@/types/lastnews";
import ListOfNewsBox from "./ListOfNewsBox";
import GetLastNews from "@/services/GetLastNews";

export default function ListOfNews() {
  const LastNewsObject: LastNews[] = GetLastNews();

  return (
    <section className="container w-[90%] mx-auto py-8">
      <h2 className="text-2xl font-bold mb-4">Ultimas Noticias</h2>
      <div className="grid grid-cols-1 md:grid-cols-2 xl:grid-cols-3 gap-6">
        {LastNewsObject.map((news) => (
          <div key={news.id} className="bg-grey rounded-lg shadow-2xl p-4 w-full">
            <ListOfNewsBox
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
