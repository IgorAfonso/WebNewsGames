"use client";

import Link from "next/link";
import { useRouter } from "next/navigation";
import { FormEvent, useState } from "react";
import { login } from "@/services/AuthService";

export default function LoginBody() {
  const router = useRouter();
  const [userName, setUserName] = useState("");
  const [password, setPassword] = useState("");
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [error, setError] = useState("");

  const handleSubmit = async (e: FormEvent) => {
    e.preventDefault();
    setError("");
    setIsSubmitting(true);

    try {
      await login({
        userName,
        password,
      });

      router.push("/");
    } catch (err) {
      setError(err instanceof Error ? err.message : "Nao foi possivel entrar.");
    } finally {
      setIsSubmitting(false);
    }
  };

  return (
    <section className="min-h-screen flex items-center justify-center px-4">
      <div className="w-full max-w-xl bg-white rounded-2xl shadow-2xl p-10">
        <h2 className="text-3xl font-bold text-darkGray mb-6 text-center">
          Entrar no Noticias Gamer
        </h2>
        <form onSubmit={handleSubmit} className="space-y-6">
          <div>
            <label htmlFor="userName" className="block text-darkGray mb-1">
              Usuario
            </label>
            <input
              type="text"
              id="userName"
              name="userName"
              value={userName}
              onChange={(e) => setUserName(e.target.value)}
              className="w-full px-4 py-3 border border-lightGray rounded-lg focus:outline-none focus:border-accent"
              placeholder="seu usuario"
              autoComplete="username"
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
              name="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              className="w-full px-4 py-3 border border-lightGray rounded-lg focus:outline-none focus:border-accent"
              placeholder="********"
              autoComplete="current-password"
              required
            />
          </div>
          {error && (
            <p className="rounded-lg bg-red-50 px-4 py-3 text-sm text-red-700">
              {error}
            </p>
          )}
          <button
            type="submit"
            disabled={isSubmitting}
            className="w-full bg-accent text-white py-3 rounded-lg hover:bg-hoverDarkBlue transition duration-200 disabled:cursor-not-allowed disabled:opacity-70"
          >
            {isSubmitting ? "Entrando..." : "Entrar"}
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
