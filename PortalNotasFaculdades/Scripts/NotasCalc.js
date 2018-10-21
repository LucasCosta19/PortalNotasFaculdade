function number_format(number, decimals, dec_point, thousands_sep) {
    var n = number, prec = decimals;

    var toFixedFix = function (n, prec) {
        var k = Math.pow(10, prec);
        return (Math.round(n * k) / k).toString();
    };

    n = !isFinite(+n) ? 0 : +n;
    prec = !isFinite(+prec) ? 0 : Math.abs(prec);
    var sep = (typeof thousands_sep === 'undefined') ? ',' : thousands_sep;
    var dec = (typeof dec_point === 'undefined') ? '.' : dec_point;

    var s = (prec > 0) ? toFixedFix(n, prec) : toFixedFix(Math.round(n), prec); //fix for IE parseFloat(0.55).toFixed(0) = 0;

    var abs = toFixedFix(Math.abs(n), prec);
    var _, i;

    if (abs >= 1000) {
        _ = abs.split(/\D/);
        i = _[0].length % 3 || 3;

        _[0] = s.slice(0, i + (n < 0)) + _[0].slice(i).replace(/(\d{3})/g, sep + '$1');
        s = _.join(dec);
    }
    else {
        s = s.replace('.', dec);
    }

    var decPos = s.indexOf(dec);

    if (prec >= 1 && decPos !== -1 && (s.length - decPos - 1) < prec) {
        s += new Array(prec - (s.length - decPos - 1)).join(0) + '0';
    }
    else if (prec >= 1 && decPos === -1) {
        s += dec + new Array(prec).join(0) + '0';
    }

    return s;
}

function zeraNotaTrabalho() {   
    document.getElementById("TrabalhoNotaN2").value = "0.00";
    document.getElementById("TrabalhoNotaN3").value = "0.00";
}
function zeraNotaProva() {
    document.getElementById("NotaProvaN2").value = "0.00";
    document.getElementById("NotaProvaN3").value = "0.00";
}

function calcular() {
    var trab1 = Number(document.getElementById("TrabalhoNotaN1").value);
    var trab2 = Number(document.getElementById("TrabalhoNotaN2").value);
    var trab3 = Number(document.getElementById("TrabalhoNotaN3").value);
    var prov1 = Number(document.getElementById("NotaProvaN1").value);
    var prov2 = Number(document.getElementById("NotaProvaN2").value);
    var prov3 = Number(document.getElementById("NotaProvaN3").value);
    var res = trab1 + trab2 + trab3 + prov1 + prov2 + prov3;
    var fullRes = res / 3;
    document.getElementById("MediaFinal").value = number_format(fullRes, 2);
}

function MascaraMoeda(objTextBox, SeparadorMilesimo, SeparadorDecimal, e) {
    var sep = 0;
    var key = '';
    var i = j = 0;
    var len = len2 = 0;
    var strCheck = '0123456789';
    var aux = aux2 = '';
    var whichCode = (window.Event) ? e.which : e.keyCode;
    if (whichCode == 13 || whichCode == 8)
        return true;
    key = String.fromCharCode(whichCode); // Valor para o código da Chave  
    if (strCheck.indexOf(key) == -1)
        return false; // Chave inválida  
    len = objTextBox.value.length;
    for (i = 0; i < len; i++)
        if ((objTextBox.value.charAt(i) != '0') && (objTextBox.value.charAt(i) != SeparadorDecimal))
            break;
    aux = '';
    for (; i < len; i++)
        if (strCheck.indexOf(objTextBox.value.charAt(i)) != -1)
            aux += objTextBox.value.charAt(i);
    aux += key;
    len = aux.length;
    if (len == 0)
        objTextBox.value = '';
    if (len == 1)
        objTextBox.value = '0' + SeparadorDecimal + '0' + aux;
    if (len == 2)
        objTextBox.value = '0' + SeparadorDecimal + aux;
    if (len > 2) {
        aux2 = '';
        for (j = 0, i = len - 3; i >= 0; i--) {
            if (j == 3) {
                aux2 += SeparadorMilesimo;
                j = 0;
            }
            aux2 += aux.charAt(i);
            j++;
        }
        objTextBox.value = '';
        len2 = aux2.length;
        for (i = len2 - 1; i >= 0; i--)
            objTextBox.value += aux2.charAt(i);
        objTextBox.value += SeparadorDecimal + aux.substr(len - 2, len);
    }
    return false;
}

//função mascara cpf, telefone
function mascara(t, mask) {
    var i = t.value.length;
    var saida = mask.substring(1, 0);
    var texto = mask.substring(i)
    if (texto.substring(0, 1) != saida) {
        t.value += texto.substring(0, 1);
    }
}

function valueF() {
    document.getElementById("AulasDadas").value = 0;
    document.getElementById("QuantidadeFaltas").value = 0;
    document.getElementById("PercentualFaltas").value = 0;
    document.getElementById("SituacaoAluno").value = "Cursando";
}

function frequencia() {
    var cargaH = Number(document.getElementById("AulasDadas").value);
    var faltas = Number(document.getElementById("QuantidadeFaltas").value);

    var percentual = (((cargaH - faltas) / cargaH) * 100);
    var totalFaltas = 100 - percentual;

    if (totalFaltas <= "9.99") {
        document.getElementById("PercentualFaltas").value = String("0"+number_format(totalFaltas, 2));
    } else {
        document.getElementById("PercentualFaltas").value = String(number_format(totalFaltas, 2));
    }    
}

function notaExame() {
    var exame = Number(document.getElementById("ExameFinal").value);   
    /*var mediaFinal = Number(document.getElementById("MediaFinal").value);  
    var CalcNotaFinal = mediaFinal + exame;
    var totalNotaFinal = CalcNotaFinal;*/
    var meta = "21.00";

    var trab1 = Number(document.getElementById("TrabalhoNotaN1").value);
    var trab2 = Number(document.getElementById("TrabalhoNotaN2").value);
    var trab3 = Number(document.getElementById("TrabalhoNotaN3").value);
    var prov1 = Number(document.getElementById("NotaProvaN1").value);
    var prov2 = Number(document.getElementById("NotaProvaN2").value);
    var prov3 = Number(document.getElementById("NotaProvaN3").value);
    var res = trab1 + trab2 + trab3 + prov1 + prov2 + prov3;

    var calcFinal = meta - res;

    if (exame >= calcFinal) {
        document.getElementById("SituacaoAluno").value = "Aprovado";
    } else {
        document.getElementById("SituacaoAluno").value = "Reprovado";
    }    

    //document.getElementById("SituacaoAluno").value = number_format(calcFinal, 2);
}

function situacaoAluno() {
    var mediaFinal = document.getElementById("MediaFinal").value;
    var faltasFinal = document.getElementById("PercentualFaltas").value;

    if (mediaFinal >= "7.00" && faltasFinal <= "09.99") {
        document.getElementById("SituacaoAluno").value = "Aprovado";
    }
    if (mediaFinal >= "7.00" && faltasFinal <= "25.00") {
        document.getElementById("SituacaoAluno").value = "Aprovado";
    }
    if (mediaFinal >= "7.00" && faltasFinal > "25.00") {
        document.getElementById("SituacaoAluno").value = "Reprovado por Falta";
    }
    if (mediaFinal < "7.00" && faltasFinal <= "25.00") {
        document.getElementById("SituacaoAluno").value = "Exame Final";
    }
    if (mediaFinal < "7.00" && faltasFinal > "25.00") {
        document.getElementById("SituacaoAluno").value = "Reprovado";
    }
}