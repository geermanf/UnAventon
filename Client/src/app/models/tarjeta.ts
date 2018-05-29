import { TipoTarjeta } from './TipoTarjeta';
import { Banco } from './Banco';

export class Tarjeta {
id: number;
nombreTitular: string;
numeroTarjeta: number;
fechaVencimiento: Date;
tipo: TipoTarjeta;
banco: Banco;
}
