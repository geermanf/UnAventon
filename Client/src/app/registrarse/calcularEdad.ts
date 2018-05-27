export function calcularEdad(fecha) {

        const values = fecha.split('-');
        const dia = values[2];
        const mes = values[1];
        const ano = values[0];

        // guardo los valores actuales
        const fecha_hoy = new Date();
        const ahora_ano = fecha_hoy.getFullYear();
        const ahora_mes = fecha_hoy.getMonth() + 1;
        const ahora_dia = fecha_hoy.getDate();

        // realizo el calculo
        let edad = (ahora_ano + 1900) - ano;
        if ( ahora_mes < mes ) {
            edad--;
        }
        if ((mes === ahora_mes) && (ahora_dia < dia)) {
            edad--;
        }
        if (edad > 1900) {
            edad -= 1900;
        }

        // calculo los meses
        let meses = 0;
        if (ahora_mes > mes) {
            meses = ahora_mes - mes;
        }
        if (ahora_mes < mes) {
            meses = 12 - (mes - ahora_mes);
        }
        if (ahora_mes === mes && dia > ahora_dia) {
            meses = 11;
        }

        // calculo los dias
        let dias = 0;
        if (ahora_dia > dia) {
            dias = ahora_dia - dia;
        }
        if (ahora_dia < dia) {
            const ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
            dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
        }

        return edad
}
