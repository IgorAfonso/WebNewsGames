"use client";

import { useRef, useState } from "react";
import { Search } from "lucide-react";

export default function HomeSearchAction() {
  const [isSearchOpen, setIsSearchOpen] = useState(false);
  const searchInputRef = useRef<HTMLInputElement>(null);
  const searchWrapperRef = useRef<HTMLDivElement>(null);

  const handleSearchClick = () => {
    if (!isSearchOpen) {
      setIsSearchOpen(true);
      window.setTimeout(() => searchInputRef.current?.focus(), 100);
      return;
    }

    alert("Pesquisar noticias");
  };

  return (
    <section className="container w-[90%] mx-auto pt-6 flex justify-end">
      <div className="flex w-full justify-end">
        <div
          ref={searchWrapperRef}
          className={`flex max-w-full items-center justify-end overflow-hidden rounded-lg shadow-lg transition-all duration-300 ${
            isSearchOpen ? "w-full sm:w-[560px]" : "w-[132px]"
          }`}
        >
          <input
            ref={searchInputRef}
            type="search"
            aria-label="Pesquisar noticias"
            placeholder="Pesquisar noticias"
            onBlur={(event) => {
              if (
                searchWrapperRef.current?.contains(
                  event.relatedTarget as Node | null,
                )
              ) {
                return;
              }

              setIsSearchOpen(false);
            }}
            className={`h-12 min-w-0 border border-r-0 border-blue-700 bg-white px-4 text-sm text-gray-900 outline-none transition-all duration-300 placeholder:text-gray-500 focus:ring-2 focus:ring-blue-300 ${
              isSearchOpen
                ? "w-full opacity-100"
                : "w-0 border-transparent px-0 opacity-0"
            }`}
          />
          <button
            type="button"
            onClick={handleSearchClick}
            className="inline-flex h-12 shrink-0 items-center justify-center gap-2 bg-blue-700 px-5 text-sm font-semibold text-white transition-all hover:bg-blue-800"
          >
            <Search className="h-5 w-5" />
            Pesquisar
          </button>
        </div>
      </div>
    </section>
  );
}
