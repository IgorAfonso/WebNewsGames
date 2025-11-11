import GetNewPosts from "@/services/GetNewPosts";
import DefaultCard from "../CardComponent/WhiteCard";
import { AlertCircle } from "lucide-react";
import { CardProps } from "@/types/CardProps";

export default function NewPosts() {
  const posts = GetNewPosts();
  //const posts: CardProps[] = [];

  // Caso não tenha posts
  if (!posts || posts.length === 0) {
    return (
      <div className="container w-[90%] mx-auto shadow-2xl my-5 col-span-full flex flex-col items-center justify-center py-16 text-center">
        <AlertCircle className="w-16 h-16 text-gray-400 mb-4" />
        <p className="text-lg text-gray-600 font-medium">
          Nenhum artigo novo no momento.
        </p>
        <p className="text-sm text-gray-500 mt-1">Volte em breve!</p>
      </div>
    );
  }

  return (
    <section className="container w-[90%] mx-auto shadow-2xl my-10 grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-5 lg:gap-6">
      {posts.map((post, index) => (
        <div
          key={post.title}
          className="transform transition-all duration-300 hover:scale-[1.02] hover:shadow-xl"
          style={{
            animation: `fadeInUp 0.5s ease-out ${index * 0.1}s both`,
          }}
        >
          <DefaultCard
            title={post.title}
            description={post.description}
            user={post.user}
          />
        </div>
      ))}
    </section>
  );
}
