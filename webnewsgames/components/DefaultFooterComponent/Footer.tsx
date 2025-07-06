export default function Footer() {
  return (
    <footer className="bg-primary text-white py-6">
      <div className="container mx-auto px-4 text-center">
        <p>&copy; 2025 Portal de Notícias. Todos os direitos reservados.</p>
        <div className="mt-4">
          <a href="#" className="text-hoverBlue hover:text-white mx-2">
            Sobre
          </a>
          <a href="#" className="text-hoverBlue hover:text-white mx-2">
            Contato
          </a>
          <a href="#" className="text-hoverBlue hover:text-white mx-2">
            Política de Privacidade
          </a>
        </div>
      </div>
    </footer>
  );
}
