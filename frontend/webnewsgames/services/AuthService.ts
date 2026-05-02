import { AxiosError } from "axios";
import { api } from "./api";
import {
  ApiResponse,
  AUTH_STORAGE_KEYS,
  AuthUser,
  LoginPayload,
} from "@/models/AuthModels";

const getLoginEndpoint = () => {
  if (process.env.NEXT_PUBLIC_LOGIN_ENDPOINT) {
    return process.env.NEXT_PUBLIC_LOGIN_ENDPOINT;
  }

  return "/auth/login";
};

function persistAuthData(authUser: AuthUser) {
  localStorage.setItem("accessToken", authUser.token);
  localStorage.setItem("tokenType", authUser.tokenType);
  localStorage.setItem("expiresAt", authUser.expiresAt);
  localStorage.setItem("userId", authUser.userId);
  localStorage.setItem("userName", authUser.userName);
  localStorage.setItem("roles", JSON.stringify(authUser.roles));
  window.dispatchEvent(new Event("auth-storage-changed"));
}

export async function login(payload: LoginPayload) {
  try {
    const { data } = await api.post<ApiResponse<AuthUser>>(
      getLoginEndpoint(),
      payload,
    );

    if (!data.success) {
      throw new Error(data.message || "Nao foi possivel fazer login.");
    }

    persistAuthData(data.data);

    return data.data;
  } catch (error) {
    if (error instanceof AxiosError) {
      const responseMessage = (error.response?.data as { message?: string })
        ?.message;

      throw new Error(responseMessage || "Nao foi possivel fazer login.");
    }

    throw error;
  }
}

export function logout() {
  AUTH_STORAGE_KEYS.forEach((key) => localStorage.removeItem(key));
  window.dispatchEvent(new Event("auth-storage-changed"));
}

export function getCurrentUser() {
  const userId = localStorage.getItem("userId");
  const userName = localStorage.getItem("userName");
  const roles = localStorage.getItem("roles");

  if (!userId || !userName) {
    return null;
  }

  return {
    userId,
    userName,
    roles: roles ? (JSON.parse(roles) as string[]) : [],
  };
}

export function isAuthenticated() {
  const token = localStorage.getItem("accessToken");
  const expiresAt = localStorage.getItem("expiresAt");

  if (!token || !expiresAt) {
    return false;
  }

  return new Date(expiresAt).getTime() > Date.now();
}
