export class ApiResponse<T> {
    data: T[];
    ok: boolean;
    message: string;
}