"use client";

import Image from "next/image";

export default function PostStatitcs() {
  const members = 1218565;
  const posts = 463535;
  const onlineMembers = 961;

  return (
    <section className="container w-[90%] mx-auto py-6">
      <div className="flex flex-col gap-5 md:flex-row md:items-center md:justify-between">
        <div className="flex flex-col gap-3 sm:flex-row sm:flex-wrap sm:items-center sm:gap-6">
          <div className="flex items-center gap-2">
            <Image src="/user.svg" alt="Members Logo" width={30} height={30} />
            <span className="font-semibold">{members}</span>
            <span>members</span>
          </div>
          <div className="flex items-center gap-2">
            <Image src="/posts.svg" alt="Posts Logo" width={30} height={30} />
            <span className="font-semibold">{posts}</span>
            <span>posts</span>
          </div>
          <div className="flex items-center gap-2">
            <Image
              src="/wifi.svg"
              alt="OnlineMembers Logo"
              width={30}
              height={30}
            />
            <span className="font-semibold">{onlineMembers}</span>
            <span>online</span>
          </div>
        </div>

        <button
          type="button"
          onClick={() => alert("Clicou em iniciar uma nova discussao")}
          className="self-start md:self-auto bg-primary text-white px-5 py-3 rounded-lg font-semibold shadow-lg hover:bg-accent transition-colors"
        >
          Iniciar uma Nova Discussao
        </button>
      </div>
    </section>
  );
}
