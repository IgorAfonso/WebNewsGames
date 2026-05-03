"use client";

import Image from "next/image";
import Link from "next/link";
import { useRouter } from "next/navigation";
import { useEffect, useState } from "react";
import { getCurrentUser, isAuthenticated, logout } from "@/services/AuthService";
import ThemeToggle from "@/components/ThemeToggle/ThemeToggle";

type HeaderUser = {
  userName: string;
};

export default function HeaderAuthActions() {
  const router = useRouter();
  const [user, setUser] = useState<HeaderUser | null>(null);

  useEffect(() => {
    const syncUser = () => {
      if (!isAuthenticated()) {
        setUser(null);
        return;
      }

      const currentUser = getCurrentUser();
      setUser(currentUser ? { userName: currentUser.userName } : null);
    };

    syncUser();

    window.addEventListener("storage", syncUser);
    window.addEventListener("auth-storage-changed", syncUser);

    return () => {
      window.removeEventListener("storage", syncUser);
      window.removeEventListener("auth-storage-changed", syncUser);
    };
  }, []);

  if (user) {
    const handleLogout = () => {
      logout();
      setUser(null);
      router.push("/");
    };

    return (
      <div className="hidden md:flex items-center justify-self-end gap-3">
        <ThemeToggle />
        <div className="flex items-center gap-3 rounded-lg bg-white px-3 py-2 text-[#1e40af] shadow-md">
          <Image
            src="/user.svg"
            width={32}
            height={32}
            alt={user.userName}
            className="h-8 w-8 rounded-full bg-blue-100 p-1"
          />
          <span className="max-w-32 truncate text-sm font-semibold">
            {user.userName}
          </span>
          <span className="text-blue-300">|</span>
          <button
            type="button"
            onClick={handleLogout}
            className="text-sm font-semibold text-[#1e40af] hover:text-blue-600 transition-colors"
          >
            Sair
          </button>
        </div>
      </div>
    );
  }

  return (
    <div className="hidden md:flex items-center justify-self-end gap-3">
      <ThemeToggle />
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
  );
}
