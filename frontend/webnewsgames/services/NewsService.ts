import { api } from "@/services/api";
import type { ApiResponse, News, NewsSummary, PagedResponse } from "@/models/NewsModels";

const DEFAULT_PAGE_SIZE = 90;

function toSummary(news: News): NewsSummary {
  return {
    id: news.id,
    title: news.title?.trim() || "Noticia sem titulo",
    description: news.content?.trim() || "Leia a noticia completa.",
    imageBase64: news.imageBase64,
  };
}

export async function getNewsById(id: string): Promise<News> {
  try {
    const response = await api.get<ApiResponse<News>>(`/news/${id}`);
    return response.data.data;
  } catch {
    const response = await api.get<ApiResponse<News>>("/news/id", {
      params: { Id: id },
    });

    return response.data.data;
  }
}

export async function getNewsList(pageSize = DEFAULT_PAGE_SIZE): Promise<NewsSummary[]> {
  const response = await api.get<ApiResponse<PagedResponse<News>>>("/news", {
    params: {
      pageNumber: 1,
      pageSize,
    },
  });

  return response.data.data.items.map(toSummary);
}

export function getNewsImageSource(imageBase64: string | null | undefined) {
  if (!imageBase64) {
    return null;
  }

  if (imageBase64.startsWith("data:")) {
    return imageBase64;
  }

  return `data:image/png;base64,${imageBase64}`;
}
