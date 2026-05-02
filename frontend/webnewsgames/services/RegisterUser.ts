import { AxiosError } from "axios";
import { api } from "./api";

export type RegisterUserPayload = {
  userName: string;
  password: string;
};

const getRegisterEndpoint = () => {
  if (process.env.NEXT_PUBLIC_REGISTER_ENDPOINT) {
    return process.env.NEXT_PUBLIC_REGISTER_ENDPOINT;
  }

  return "/auth/users";
};

export default async function RegisterUser(payload: RegisterUserPayload) {
  try {
    const { data } = await api.post(getRegisterEndpoint(), payload);
    return data ?? null;
  } catch (error) {
    if (error instanceof AxiosError) {
      const responseMessage = (error.response?.data as { message?: string })
        ?.message;

      throw new Error(responseMessage || "Nao foi possivel cadastrar o usuario.");
    }

    throw error;
  }
}
