export interface ApiResponse<T> {
  success: boolean;
  message: string;
  data: T;
}

export interface PagedResponse<T> {
  items: T[];
  pageNumber: number;
  pageSize: number;
  totalItems: number;
  totalPages: number;
}

export interface News {
  id: string;
  title: string | null;
  content: string | null;
  imageBase64: string | null;
  imageCaption: string | null;
  content2: string | null;
  image2Base64: string | null;
  image2Caption: string | null;
  content3: string | null;
  image3Base64: string | null;
  image3Caption: string | null;
  authorName: string | null;
}

export interface NewsSummary {
  id: string;
  title: string;
  description: string;
  imageBase64: string | null;
}
