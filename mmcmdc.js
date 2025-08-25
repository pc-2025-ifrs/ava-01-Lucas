// MDC 
function mdcSimples(a, b) {
  if (!Number.isInteger(a) || !Number.isInteger(b)) {
    return null;
  }
  
  a = Math.abs(a);
  b = Math.abs(b);

  while (b) {
    [a, b] = [b, a % b];
  }

  return a;
}

// MMC
function mmcSimples(n1, n2) {
  const mdcVal = mdcSimples(n1, n2);

  if (mdcVal === null) {
    return null;
  }
  
  if (mdcVal === 0) {
    return 0;
  }

  return Math.abs(n1 * n2) / mdcVal;
}

// test
console.log("MMC de 3 e 4:", mmcSimples(3, 4));
console.log("MMC de 18 e 131:", mmcSimples(18, 131));
console.log("MDC de 30 e 45:", mdcSimples(30, 45));
console.log("MDC de -100 e 0:", mdcSimples(-100, 0));