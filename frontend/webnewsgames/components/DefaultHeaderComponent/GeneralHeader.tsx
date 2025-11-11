import Link from "next/link";

export default function GeneralHeader({
  PageDescriptor,
}: {
  PageDescriptor: string;
}) {
  return (
    <header className="bg-primary text-white py-4 shadow-lg">
      <div className="container w-[90%] mx-auto flex flex-col md:flex-row justify-between items-center gap-4 md:gap-0">
        {/* Título / Logo */}
        <h1 className="text-2xl md:text-3xl font-bold tracking-wide">
          {PageDescriptor}
        </h1>

        {/* Menu principal */}
        <nav className="flex items-center gap-6">
          <ul className="flex flex-col md:flex-row md:space-x-6 text-sm md:text-base font-medium">
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
            <li>
              <Link
                href="/inovations"
                className="hover:text-blue-300 transition-colors"
              >
                Inovações
              </Link>
            </li>
          </ul>

          {/* Botões de Login / Cadastro */}
          <div className="hidden md:flex items-center gap-3 ml-6">
            <Link
              href="/login"
              className="px-4 py-2 border border-white/60 rounded-lg text-sm font-medium hover:bg-white hover:text-[#1e40af] transition-colors"
            >
              Login
            </Link>
            <Link
              href="/register"
              className="px-4 py-2 bg-white text-[#1e40af] rounded-lg text-sm font-semibold hover:bg-blue-100 transition-colors"
            >
              Cadastrar-se
            </Link>
          </div>
        </nav>
      </div>
    </header>
  );
}
