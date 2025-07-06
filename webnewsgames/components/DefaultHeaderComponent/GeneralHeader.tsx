import Link from "next/link";

export default function GeneralHeader({
  PageDescriptor,
}: {
  PageDescriptor: string;
}) {
  return (
    <header className="bg-primary text-white py-4">
      <div className="container mx-auto px-4 flex justify-between items-center">
        <h1 className="text-3xl font-bold">{PageDescriptor}</h1>
        <div className="flex space-x-6">
          <ul className="flex space-x-6">
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
