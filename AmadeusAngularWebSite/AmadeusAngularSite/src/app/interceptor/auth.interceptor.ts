import { HttpInterceptorFn } from '@angular/common/http';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  if(req.url.indexOf("login")>0) return next(req);
    const request= req.clone({
    setHeaders:{
      Authorization:`Bearer ${localStorage.getItem("token")}`
    }
  })
  return next(request);
  
};
