export type AuthUser = {
  token: string;
  tokenType: string;
  expiresAt: string;
  userId: string;
  userName: string;
  roles: string[];
};

export type ApiResponse<T> = {
  success: boolean;
  message: string;
  data: T;
};

export type LoginPayload = {
  userName: string;
  password: string;
};

export const AUTH_STORAGE_KEYS = [
  "accessToken",
  "tokenType",
  "expiresAt",
  "userId",
  "userName",
  "roles",
];
