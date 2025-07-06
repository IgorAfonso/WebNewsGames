import Image from "next/image";
import Members from "@/public/user.svg";
import Posts from "@/public/posts.svg";
import OnlineMembers from "@/public/wifi.svg";

export default function PostStatitcs() {
  const members = 1218565;
  const posts = 463535;
  const onlineMembers = 961;

  return (
    <div className="flex flex-col md:flex-row w-full p-4 m-5 container mx-auto justify-between items-center">
      <div className="flex flex-col lg:flex-row md:w-[50%] md:items-center md:justify-between my-4 gap-4">
        <div className="flex flex-row gap-3 items-center">
          <Image src={Members} alt="Members Logo" width={30} height={30} />
          <h3>{members}</h3>
          <h3>members</h3>
        </div>
        <div className="flex flex-row gap-3 items-center">
          <Image src={Posts} alt="Posts Logo" width={30} height={30} />
          <h3>{posts}</h3>
          <h3>posts</h3>
        </div>
        <div className="flex flex-row gap-3 items-center">
          <Image
            src={OnlineMembers}
            alt="OnlineMembers Logo"
            width={30}
            height={30}
          />
          <h3>{onlineMembers}</h3>
          <h3>online</h3>
        </div>
      </div>
      <button className="bg-primary h-15 text-white px-3 rounded-2xl">
        Iniciar uma Nova Discussão
      </button>
    </div>
  );
}
