import Link from "next/link";

export default function LoginHeaderComponent() {
  return (
    <header className="bg-primary text-white py-4 text-center">
      <Link
        href="/"
        className="inline-block text-3xl font-bold hover:text-hoverBlue transition-colors"
      >
        Notícias Gamer
      </Link>
    </header>
  );
}
