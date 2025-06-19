"use client";
import Link from "next/link";
import { FormEvent } from "react";

export default function LoginBody() {
  const handleSubmit = (e: FormEvent) => {
    e.preventDefault();
    alert("Login submitted! Implemente a lógica de autenticação aqui.");
  };

  return (
    <section className="min-h-screen flex items-center justify-center px-4">
      <div className="w-full max-w-xl bg-white rounded-2xl shadow-2xl p-10">
        <h2 className="text-3xl font-bold text-darkGray mb-6 text-center">
          Entrar no Notícias Gamer
        </h2>
        <form onSubmit={handleSubmit} className="space-y-6">
          <div>
            <label htmlFor="email" className="block text-darkGray mb-1">
              E-mail
            </label>
            <input
              type="email"
              id="email"
              className="w-full px-4 py-3 border border-lightGray rounded-lg focus:outline-none focus:border-accent"
              placeholder="seu@email.com"
              required
            />
          </div>
          <div>
            <label htmlFor="password" className="block text-darkGray mb-1">
              Senha
            </label>
            <input
              type="password"
              id="password"
              className="w-full px-4 py-3 border border-lightGray rounded-lg focus:outline-none focus:border-accent"
              placeholder="********"
              required
            />
          </div>
          <button
            type="submit"
            className="w-full bg-accent text-white py-3 rounded-lg hover:bg-hoverDarkBlue transition duration-200"
          >
            Entrar
          </button>
          <div className="flex justify-between text-sm pt-2">
            <Link
              href="/forgot-password"
              className="text-accent hover:text-hoverBlue"
            >
              Esqueci minha senha
            </Link>
            <Link href="/register" className="text-accent hover:text-hoverBlue">
              Criar conta
            </Link>
          </div>
        </form>
      </div>
    </section>
  );
}
