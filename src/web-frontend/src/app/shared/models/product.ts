import { IDiscount } from './discount';
import { IPhoto } from './photo';
import { IProductSpecifications } from './productSpecification';
import { IProductTags } from './productTag';

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
    photos: IPhoto;
    productTags: string[];
    productSpecifications: IProductSpecifications;
}