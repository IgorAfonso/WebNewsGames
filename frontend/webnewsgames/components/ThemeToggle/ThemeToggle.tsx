"use client";

import { Moon, Sun } from "lucide-react";
import { useTheme } from "@/contexts/ThemeContext";

export default function ThemeToggle({ className = "" }: { className?: string }) {
  const { isDarkTheme, toggleTheme } = useTheme();

  return (
    <button
      type="button"
      role="switch"
      aria-checked={isDarkTheme}
      aria-label={isDarkTheme ? "Ativar tema claro" : "Ativar tema escuro"}
      onClick={toggleTheme}
      className={`theme-toggle inline-flex h-12 items-center gap-3 rounded-lg border border-app bg-surface px-3 text-sm font-semibold text-app shadow-lg transition-colors hover:border-accent hover:text-accent ${className}`}
    >
      <span
        className={`relative inline-flex h-6 w-11 items-center rounded-full transition-colors ${
          isDarkTheme ? "bg-accent" : "bg-gray-300"
        }`}
      >
        <span
          className={`inline-flex h-5 w-5 items-center justify-center rounded-full bg-white text-blue-700 shadow transition-transform ${
            isDarkTheme ? "translate-x-5" : "translate-x-1"
          }`}
        >
          {isDarkTheme ? (
            <Moon className="h-3.5 w-3.5" />
          ) : (
            <Sun className="h-3.5 w-3.5" />
          )}
        </span>
      </span>
      <span>Tema escuro</span>
    </button>
  );
}
