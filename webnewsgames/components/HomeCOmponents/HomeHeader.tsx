export default function HeaderComponent() {
  return (
    <header className="bg-primary text-white py-4">
      <div className="container mx-auto px-4 flex justify-between items-center">
        <h1 className="text-3xl font-bold">Notícias Gamer</h1>
        <div className="flex space-x-6">
          <ul className="flex space-x-6">
            <li>
              <a href="" className="hover:hoverBlue">
                Home
              </a>
            </li>
            <li>
              <a href="" className="hover:thoverBlue">
                Comunidade
              </a>
            </li>
            <li>
              <a href="" className="hover:hoverBlue">
                Campeonatos
              </a>
            </li>
            <li>
              <a href="" className="hover:hoverBlue">
                Inovações
              </a>
            </li>
          </ul>
        </div>
      </div>
    </header>
  );
}
