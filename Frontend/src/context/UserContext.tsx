import React, { createContext, useState, ReactNode, useContext } from "react";
import axios, { AxiosError, AxiosResponse } from "axios";
import { User } from "../types";

// const API_BASE = import.meta.env.VITE_API_BASE;
const API_BASE = "https://roe-api.azurewebsites.net";

interface UserContextProps {
  user: User | undefined;
  login: (user: User) => Promise<void>;
  register: (user: User) => Promise<User>;
  logout: () => void;
}

interface UserProviderProps {
  children: ReactNode;
}

export const UserContext = createContext<UserContextProps | undefined>(
  undefined
);

const UserProvider: React.FC<UserProviderProps> = ({ children }) => {
  const [user, setUser] = useState(() => {
    const localData = localStorage.getItem("userData");
    return localData ? JSON.parse(localData) : undefined;
  });

  const login = async (user: User) => {
    console.log(API_BASE);
    await axios
      .post(`${API_BASE}/Student/login`, user)
      .then((res: AxiosResponse) => {
        setUser(res.data);
        localStorage.setItem("userData", JSON.stringify(user));
      })
      .catch((error: AxiosError) => {
        throw error;
      });
  };

  const register = async (user: User) => {
    return await axios
      .post(`${API_BASE}/Student/register`, user)
      .then((res: AxiosResponse) => {
        setUser(res.data);
        localStorage.setItem("userData", JSON.stringify(user));
        return res.data;
      })
      .catch((error: AxiosError) => {
        throw error;
      });
  };

  const logout = () => {
    setUser(undefined);
    localStorage.removeItem("userData");
  };

  return (
    <UserContext.Provider value={{ user: user, login, register, logout }}>
      {children}
    </UserContext.Provider>
  );
};

export const useUser = () => useContext(UserContext);

export default UserProvider;
