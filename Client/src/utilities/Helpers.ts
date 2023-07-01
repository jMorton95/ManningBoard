
export const getInitials = (fullName: string): string => fullName.split(' ').map(x => x[0]).join('').toUpperCase();
