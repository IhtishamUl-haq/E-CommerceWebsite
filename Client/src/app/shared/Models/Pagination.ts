import { IProducts } from "./Products"

export interface IPagination {
    pageIndex: number
    pageSize: number
    count: number
    data: IProducts[]
  }