import Link from "next/link";

export default function GeneralHeader({
  PageDescriptor,
}: {
  PageDescriptor: string;
}) {
  return (
    <header className="bg-primary text-white py-4">
      <div className="container mx-auto gap-4 md:gap-0 px-4 flex flex-col md:flex-row justify-between items-center">
        <h1 className="text-3xl font-bold">{PageDescriptor}</h1>
        <div className="flex">
          <ul className="flex flex-col md:flex-row md:space-x-6">
            <li>
              <Link href="/" className="hover:hoverBlue">
                Home
              </Link>
            </li>
            <li>
              <Link className="hover:thoverBlue" href="/community">
                Comunidade
              </Link>
            </li>
            <li>
              <Link href="/championships" className="hover:hoverBlue">
                Campeonatos
              </Link>
            </li>
            <li>
              <Link href="/inovations" className="hover:hoverBlue">
                Inovações
              </Link>
            </li>
          </ul>
        </div>
      </div>
    </header>
  );
}
