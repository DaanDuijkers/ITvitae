import Brand from './Brand';

export default interface Phone
{
    id: number;
    brandId: number;
    brand: Brand;
    type: string;
    description: string;
    price: number;
    stock: number;
}