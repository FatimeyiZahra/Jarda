import { IDiscount } from './discount';

export interface IProduct{
    id: number;
    name: string;
    developer: string;
    publisher: string;
    releaseDate: string;
    rating: string;
    desc: string;
    video: string;
    price: number;
    addedDate: string;
    discount: IDiscount;
    photos: string[];
    productTags: string[];
    productSpecifications: string[];
}