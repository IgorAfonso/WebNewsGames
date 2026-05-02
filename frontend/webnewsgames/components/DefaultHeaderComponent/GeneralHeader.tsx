import Link from "next/link";
import HeaderAuthActions from "./HeaderAuthActions";

export default function GeneralHeader({
  PageDescriptor,
}: {
  PageDescriptor: string;
}) {
  return (
    <header className="bg-primary text-white py-4 shadow-lg">
      <div className="container w-[90%] mx-auto grid grid-cols-1 md:grid-cols-[auto_1fr_auto] items-center gap-4">
        <h1 className="justify-self-center md:justify-self-start text-2xl md:text-3xl font-bold tracking-wide">
          <Link href="/" className="hover:text-blue-300 transition-colors">
            {PageDescriptor}
          </Link>
        </h1>

        <nav className="justify-self-center">
          <ul className="flex flex-col md:flex-row items-center gap-3 md:gap-6 text-sm md:text-base font-medium">
            <li>
              <Link href="/" className="hover:text-blue-300 transition-colors">
                Home
              </Link>
            </li>
            <li>
              <Link
                href="/community"
                className="hover:text-blue-300 transition-colors"
              >
                Comunidade
              </Link>
            </li>
            <li>
              <Link
                href="/championships"
                className="hover:text-blue-300 transition-colors"
              >
                Campeonatos
              </Link>
            </li>
          </ul>
        </nav>

        <HeaderAuthActions />
      </div>
    </header>
  );
}
