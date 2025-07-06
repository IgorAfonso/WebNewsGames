import GetNewPosts from "@/services/GetNewPosts";
import DefaultCard from "../CardComponent/WhiteCard";

export default function NewPosts() {
  const NewPosts = GetNewPosts();

  return (
    <section className="container mx-auto px-4 h-full w-full">
      <h1 className="text-3xl font-bold">Artigos novos</h1>
      <div className="my-5 grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-4">
        {NewPosts.map((x) => {
          return (
            <DefaultCard
              key={x.title}
              title={x.title}
              description={x.description}
              user={x.user}
            />
          );
        })}
      </div>
    </section>
  );
}
